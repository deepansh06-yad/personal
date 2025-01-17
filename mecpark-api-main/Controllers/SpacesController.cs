﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Spaces;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpacesController : ControllerBase
    {
        private ISpaceService _spaceService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public SpacesController(
            ISpaceService spaceService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _spaceService = spaceService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [Authorize(Roles = "AllocationManager")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateSpaceModel model)
        {
            var space = _mapper.Map<Space>(model);
            var context = HttpContext.User.Identity;
            int id = int.Parse(context.Name);
            try
            {
                _spaceService.Create(space, id);
                return Ok(new { message = "✓ Space Creation Success" });
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetSpaces()
        {
            var spaces = _spaceService.GetSpaces();
            var model = _mapper.Map<IList<Space>>(spaces);
            return Ok(model);
        }

        [Authorize(Roles = "AllocationManager")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSpaceModel model)
        {
            var context = HttpContext.User.Identity;
            var userId = int.Parse(context.Name);
            var space = _mapper.Map<Space>(model);
            space.Id = id;

            try
            {
                _spaceService.Update(userId, space);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "AllocationManager")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context = HttpContext.User.Identity;
            var userId = int.Parse(context.Name);
            _spaceService.Delete(userId, id);
            return Ok();
        }

    }
}
