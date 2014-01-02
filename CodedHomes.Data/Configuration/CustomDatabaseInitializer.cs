using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using CodedHomes.Models;
using Devtalk.EF.CodeFirst;

namespace CodedHomes.Data.Configuration
{
    public class CustomDatabaseInitializer :
        DontDropDbJustCreateTablesIfModelChanged<DataContext>
        //CreateDatabaseIfNotExists<DataContext>
    {
   
        }
    }

    




