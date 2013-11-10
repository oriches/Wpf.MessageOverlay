namespace Wpf.MessageOverlay.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using Helpers;

    public abstract class Bindable : IBindable
    {
        public event PropertyChangingEventHandler PropertyChanging = delegate { };

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected bool SetPropertyAndNotify<T>(ref T currentValue, T newValue, Expression<Func<T>> propertyExpression)
        {
            return SetPropertyAndNotify(ref currentValue, newValue, ExpressionHelper.Name(propertyExpression));
        }

        protected void RaisePropertyChanging<T>(Expression<Func<T>> expression)
        {
            RaisePropertyChanging(ExpressionHelper.Name(expression));
        }

        private void RaisePropertyChanging(string propertyName)
        {
            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> expression)
        {
            RaisePropertyChanged(ExpressionHelper.Name(expression));
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetPropertyAndNotify<T>(ref T currentValue, T newValue, string propertyName)
        {
            if (Equals(currentValue, newValue))
            {
                return false;
            }

            RaisePropertyChanging(propertyName);
            currentValue = newValue;
            RaisePropertyChanged(propertyName);

            return true;
        }
    }
}