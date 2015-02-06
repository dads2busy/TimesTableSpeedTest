using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimesTableSpeedTest
{
    public class Equation
    {
        public float leftTerm { get; set; }
        public float rightTerm { get; set; }
        public Operation operation { get; set; }
        public float answer { get; set; }
        public int order { get; set; }
    }
}
