﻿using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Interfaces
{
    public interface IGuideRepository
    {
        IEnumerable<Guide> GetAllGuides();
        Guide GetGuideById(int id);
        void AddGuide(Guide product);
        void UpdateGuide(Guide product);
        void DeleteGuide(int id);
    }
}
