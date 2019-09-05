using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;

namespace ContactsManager
{
    public interface ISQLiteInterface
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
