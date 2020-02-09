using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// <see cref="DependencyObject"/> helper
    /// </summary>
    public static class DependencyObjectHelper
    {
        /// <summary>
        /// Find parent
        /// </summary>
        /// <typeparam name="TDependencyObject">type of object sought</typeparam>
        /// <param name="child"></param>
        /// <returns>parent object</returns>
        /// <remarks>
        /// Thanks https://stackoverflow.com/questions/15198104/find-parent-of-control-by-name
        /// </remarks>
        public static TDependencyObject FindParentByType<TDependencyObject>(this DependencyObject child)
            where TDependencyObject : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            TDependencyObject parent = parentObject as TDependencyObject;
            if (parent != null)
                return parent;
            else
                return FindParentByType<TDependencyObject>(parentObject);
        }

        /// <summary>
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="TDependencyObject">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, 
        /// a null parent is being returned.</returns>
        public static TDependencyObject FindChildByName<TDependencyObject>(this DependencyObject parent, string childName)
           where TDependencyObject : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            TDependencyObject foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                TDependencyObject childType = child as TDependencyObject;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChildByName<TDependencyObject>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (TDependencyObject)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (TDependencyObject)child;
                    break;
                }
            }

            return foundChild;
        }
    }
}
