using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace DNA.PropertyClass
{
    class D1TextBoxProperty
    {
        [Category("常规"), Description("字段名"), DisplayName("字段名")]
        public String Name { get; set; }
        [Category("常规"), Description("标题"), DisplayName("标题")]
        public String LabelName { get; set; }
    }
}
