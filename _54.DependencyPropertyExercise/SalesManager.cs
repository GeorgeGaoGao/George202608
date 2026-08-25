using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace _54.DependencyPropertyExercise
{
    public class SalesManager
    {
        public static readonly RoutedEvent CheckEvent =
            EventManager.RegisterRoutedEvent(
                name: "CheckEvent",
                routingStrategy: RoutingStrategy.Bubble,
                handlerType: typeof(RoutedEventHandler),
                typeof(SalesManager));
        public static void AddCheckHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            if (dependencyObject is UIElement element)
            {
                element.AddHandler(CheckEvent, handler);
            }
        }
        public static void RemoveCheckHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            if (dependencyObject is UIElement element)
            {
                element.RemoveHandler(CheckEvent, handler);
            }
        }
    }
}
