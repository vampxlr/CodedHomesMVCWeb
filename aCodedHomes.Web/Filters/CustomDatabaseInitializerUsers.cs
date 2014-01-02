using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using CodedHomes.Models;
using Devtalk.EF.CodeFirst;
using CodedHomes.Web.Models;

namespace CodedHomes.Data.Configuration
{
    public class CustomDatabaseInitializerUsers:
        DontDropDbJustCreateTablesIfModelChanged<UsersContext>
        //CreateDatabaseIfNotExists<DataContext>
    {
   
        }
    }

    




