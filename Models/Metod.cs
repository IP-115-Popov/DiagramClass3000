﻿using Avalonia.Controls;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DiagramClass.Models
{
    public class Metod : AbstractNotifyPropertyChanged
    {
        private string? access;
        private string? myReturn;
        private string? name;
        private string? arguments;
        public string? Аccess
        {
            get => access;
            set => SetAndRaise(ref access, value);
        }
        public string? Return
        {
            get => myReturn;
            set => SetAndRaise(ref myReturn, value);
        }

        public string? Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }
        public string? Arguments
        {
            get => arguments;
            set => SetAndRaise(ref arguments, value);
        }
    }
}
