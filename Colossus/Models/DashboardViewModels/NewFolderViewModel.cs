﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace Aiursoft.Colossus.Models.DashboardViewModels
{
    public class NewFolderViewModel : LayoutViewModel
    {
        [Obsolete(message: "This method is only for framework", error: true)]
        public NewFolderViewModel() { }
        public NewFolderViewModel(ColossusUser user) : base(user, 1, "Create new folder") { }
        public void Recover(ColossusUser user)
        {
            RootRecover(user, 1, "Create new folder");
        }

        public string NewFolderName { get; set; }

        [FromRoute]
        public string Path { get; set; }
    }
}
