﻿using Microsoft.AspNetCore.Mvc;
using Transaction_api.Models;
using Transaction_api.Repositories;

namespace Transaction_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class StoreClusterController:ControllerBase
    {
        private StoreClusterRepo _storeClusterRepo;

        public StoreClusterController(StoreClusterRepo Repo)
        {
            _storeClusterRepo = Repo;
        }


        [HttpGet]
        public ActionResult<List<StoreCluster>> getall()
        {
            return _storeClusterRepo.getall().Result;
        }
    }
}
