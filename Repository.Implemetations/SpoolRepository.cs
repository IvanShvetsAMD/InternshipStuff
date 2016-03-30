using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NHibernate;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal class SpoolRepository: Repository<Spool>, ISpoolRepository
    {
        //public new void Save(Spool spool)
        //{
        //    //_session = SessionGenerator.Instance.GetSession();
        //    using (ITransaction transaction = _session.BeginTransaction())
        //    {
        //        var bladeRepository = new BladeRepository();
        //        if (spool != null)
        //        {
                   
        //            {
        //                foreach (var blade in spool.Blades)
        //                {
        //                    blade.ParentSpool = spool;
        //                    //bladeRepository.Save(blade);
                            
        //                }
        //            }
        //        }

        //        _session.SaveOrUpdate(spool);

        //        transaction.Commit();
        //    }
        //   // _session.Close();
        //}
    }
}