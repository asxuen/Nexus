﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aiursoft.Account.Models.AccountViewModels
{
    public abstract class AccountViewModel
    {
        [Obsolete(error: true, message: "This method is only for framework!")]
        public AccountViewModel() { }
        public AccountViewModel(AccountUser user, int activePanel, string title)
        {
            this.Recover(user, activePanel, title);
        }

        public virtual bool ModelStateValid { get; set; } = true;
        public virtual bool JustHaveUpdated { get; set; } = false;

        public virtual void Recover(AccountUser user, int activePanel, string title)
        {
            this.EmailConfirmed = user.EmailConfirmed;
            this.UserName = user.NickName;
            this.UserIconFileKey = user.HeadImgFileKey;
            this.ActivePanel = activePanel;
            this.Title = title;
        }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string UserName { get; set; }
        public virtual int UserIconFileKey { get; set; }
        public virtual int ActivePanel { get; set; }
        public virtual string Title { get; set; }
    }
}
