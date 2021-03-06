﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using ININ.Alliances.RecursiveLabsAddin.Properties;

namespace ININ.Alliances.RecursiveLabsAddin.view
{
    /// <summary>
    /// Interaction logic for BooleanToggle.xaml
    /// </summary>
    public partial class BooleanToggle : INotifyPropertyChanged
    {

        #region Private Fields



        #endregion



        #region Dependency Properties


        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(bool), typeof(BooleanToggle), new PropertyMetadata(false, ValuePropertyChanged));

        public bool Value
        {
            get { return (bool)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty TrueTextProperty = DependencyProperty.Register(
            "TrueText", typeof(string), typeof(BooleanToggle), new PropertyMetadata("on"));

        public string TrueText
        {
            get { return (string)GetValue(TrueTextProperty); }
            set
            {
                SetValue(TrueTextProperty, value);
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty TrueTextColorProperty = DependencyProperty.Register(
            "TrueTextColor", typeof(Color), typeof(BooleanToggle), new PropertyMetadata(Colors.Black, TextColorPropertyChanged));

        public Color TrueTextColor
        {
            get { return (Color)GetValue(TrueTextColorProperty); }
            set
            {
                SetValue(TrueTextColorProperty, value);
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty TrueColorProperty = DependencyProperty.Register(
            "TrueColor", typeof(Color), typeof(BooleanToggle), new PropertyMetadata(Colors.DarkGreen, ColorPropertyChanged));

        public Color TrueColor
        {
            get { return (Color)GetValue(TrueColorProperty); }
            set
            {
                SetValue(TrueColorProperty, value);
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty FalseTextProperty = DependencyProperty.Register(
            "FalseText", typeof(string), typeof(BooleanToggle), new PropertyMetadata("off"));

        public string FalseText
        {
            get { return (string)GetValue(FalseTextProperty); }
            set
            {
                SetValue(FalseTextProperty, value);
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty FalseTextColorProperty = DependencyProperty.Register(
            "FalseTextColor", typeof(Color), typeof(BooleanToggle), new PropertyMetadata(Colors.Black, TextColorPropertyChanged));

        public Color FalseTextColor
        {
            get { return (Color)GetValue(FalseTextColorProperty); }
            set
            {
                SetValue(FalseTextColorProperty, value);
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty FalseColorProperty = DependencyProperty.Register(
            "FalseColor", typeof(Color), typeof(BooleanToggle), new PropertyMetadata(Colors.DarkRed, ColorPropertyChanged));

        public Color FalseColor
        {
            get { return (Color)GetValue(FalseColorProperty); }
            set
            {
                SetValue(FalseColorProperty, value);
                OnPropertyChanged();
            }
        }

        #endregion



        #region Public Properties

        public event PropertyChangedEventHandler PropertyChanged;

        public Brush TrueBackgroundBrush
        {
            get
            {
                return Value
                    ? new SolidColorBrush(TrueColor)
                    : new SolidColorBrush(Colors.DarkGray);
            }
        }

        public Brush FalseBackgroundBrush
        {
            get
            {
                return Value
                    ? new SolidColorBrush(Colors.DarkGray)
                    : new SolidColorBrush(FalseColor);
            }
        }

        public Brush TrueTextBrush
        {
            get
            {
                return new SolidColorBrush(TrueTextColor);
            }
        }

        public Brush FalseTextBrush
        {
            get
            {
                return new SolidColorBrush(FalseTextColor);
            }
        }

        #endregion



        public BooleanToggle()
        {
            InitializeComponent();
        }



        #region Private Methods

        private static void ValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                // Cast to an instance of "this"
                var toggle = sender as BooleanToggle;
                if (toggle == null) throw new Exception("Sender was of unexpected type! Expected BooleanToggle; Encountered: " + sender.GetType());

                // Send notifications
                toggle.OnPropertyChanged("TrueBackgroundBrush");
                toggle.OnPropertyChanged("FalseBackgroundBrush");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        private static void ColorPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                // Cast to an instance of "this"
                var toggle = sender as BooleanToggle;
                if (toggle == null) throw new Exception("Sender was of unexpected type! Expected BooleanToggle; Encountered: " + sender.GetType());

                // Send notifications
                toggle.OnPropertyChanged("TrueBackgroundBrush");
                toggle.OnPropertyChanged("FalseBackgroundBrush");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        private static void TextColorPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                // Cast to an instance of "this"
                var toggle = sender as BooleanToggle;
                if (toggle == null) throw new Exception("Sender was of unexpected type! Expected BooleanToggle; Encountered: " + sender.GetType());

                // Send notifications
                toggle.OnPropertyChanged("TrueTextBrush");
                toggle.OnPropertyChanged("FalseTextBrush");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Value = !Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RecursiveLabsAddin.AddinTracer.Exception(ex);
            }
        }

        #endregion



        #region Public Methods

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
