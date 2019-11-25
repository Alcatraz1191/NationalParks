using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NationalParks.Models;
using System.Data.Entity;

namespace NationalParks.DAL
{
    public class ParkInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ParkContext>
    {
        protected override void Seed(ParkContext context)
        {
            APIHandlerManager.APIHandler API = new APIHandlerManager.APIHandler();
            var ParkList = API.GetParks();
            ParkList.data.ForEach(s => context.Parks.Add(s));
            var VisitorCentreList = API.GetVisitorCentres();
            VisitorCentreList.data.ForEach(s => context.Visitors.Add(s));
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.EntityCommandCompilationException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                Console.WriteLine(ex.InnerException);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }
        }
    }
}