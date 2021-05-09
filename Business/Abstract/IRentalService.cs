﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        List<Rental> GetAll();
        Rental GetById(int id);
        void Add(Rental entity);
        void Update(Rental entity);
        void Delete(Rental entity);
    }
}
