using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AnxietyNZ.classes
{
    class contributor_test
    {
        [PrimaryKey, AutoIncrement]
        public int contributor_id { get; set; }
        public string contributor_name { get; set; }
        public string contributor_email { get; set; }
        public string contributor_phone_number { get; set; }
        public string contributor_address { get; set; }
    }
}
