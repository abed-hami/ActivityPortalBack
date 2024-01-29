﻿using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Interfaces
{
    public interface IGuideEventRepository 
    {
        IEnumerable<GuidesEvent> GetAllGuideEvents();
        GuidesEvent GetGuideEventById(int id);
        String AddGuideEvent(GuidesEvent product);
        void UpdateGuideEvent(GuidesEvent product);
        void DeleteGuideEvent(int id);
        IEnumerable<dynamic> GetAssignedGuides();

    }
}
