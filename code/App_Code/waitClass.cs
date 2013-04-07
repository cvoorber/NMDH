using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class waitClass
{
    public IQueryable<ndmh_wait> getWait()
    {
        ndmhDCDataContext objWaitDC = new ndmhDCDataContext();
        var allWait = objWaitDC.ndmh_waits.Select(x => x);
        return allWait;
    }

    public bool commitUpdate(int _id, decimal _patients, decimal _onstaff, DateTime _updated, decimal _estimate)
    {
        ndmhDCDataContext objWaitDC = new ndmhDCDataContext();
        using (objWaitDC)
        {
            var objUpWait = objWaitDC.ndmh_waits.Single(x => x.w_id == _id);
            var objPatients = objWaitDC.ndmh_waits.Where(x => x.w_id == _id).Select(x => x.w_patients);
            objUpWait.w_id = _id;
            objUpWait.w_patients = _patients;
            objUpWait.w_onstaff = _onstaff;
            objUpWait.w_updated = _updated;
            objUpWait.w_estimate = _estimate;
            //commit update against DB
            objWaitDC.SubmitChanges();
            return true;
        }
    }
}