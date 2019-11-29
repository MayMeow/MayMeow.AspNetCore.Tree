using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MayMeow.Tree
{
    /// <summary>
    /// 
    /// </summary>
    public static class NodeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static IEnumerable<T> Values<T>(this IEnumerable<Node<T>> nodes)
        {
            return nodes.Select(n => n.Value);
        }
    }
}
