﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aiursoft.Colossus.Models.DashboardViewModels
{
    public class LayoutViewModel
    {
        [Obsolete(error: true, message: "This method is only for framework!")]
        public LayoutViewModel() { }
        public LayoutViewModel(ColossusUser user, int activePanel, string title)
        {
            this.Recover(user, activePanel, title);
        }

        public virtual bool ModelStateValid { get; set; } = true;
        public virtual bool JustHaveUpdated { get; set; } = false;

        public virtual void Recover(ColossusUser user, int activePanel, string title)
        {
            this.UserName = user.NickName;
            this.UserIconFileKey = user.HeadImgFileKey;
            this.ActivePanel = activePanel;
            this.Title = title;
        }
        public virtual string UserName { get; set; }
        public virtual int UserIconFileKey { get; set; }
        public virtual int ActivePanel { get; set; }
        public virtual string Title { get; set; }
    }
}
