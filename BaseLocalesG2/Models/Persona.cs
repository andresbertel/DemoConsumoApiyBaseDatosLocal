﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLocalesG2.Models
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

    }
}
