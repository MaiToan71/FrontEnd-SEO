﻿using Project.Proxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy.Interfaces
{
    public interface IBanner
    {
        Task<List<BannerViewModel>> GetHomeBanner();
    }
}
