﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentDALLibrary
{
    public interface IRepositoryInterface <K,T>where T : class
    {

        T Add(T item);
        List <T> GetAll();

        T GetById(K key);

        T Update(T item);

        T DeleteById(K key);








    }
}
