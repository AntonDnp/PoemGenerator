﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.Models
{
    public class Verb
    {

        // ID word
        public int Id { get; set; }
        // percussive syllable
        public string First { get; set; }
        // full word
        public string Full_Word { get; set; }
    }
}