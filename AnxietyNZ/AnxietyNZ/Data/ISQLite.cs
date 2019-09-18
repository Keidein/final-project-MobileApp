using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnxietyNZ.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
