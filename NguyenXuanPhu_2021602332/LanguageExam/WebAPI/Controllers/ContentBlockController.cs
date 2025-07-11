﻿using Application.Dtos.ContentBlockDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentBlockController : ControllerBase
    {
        private readonly IContentBlockService _contentBlockService;
        public ContentBlockController(IContentBlockService contentBlockService)
        {
            _contentBlockService = contentBlockService;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ContentBlockUpdateDto contentBlockUpdateDto)
        {
            await _contentBlockService.Update(contentBlockUpdateDto);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] List<ContentBlockCreateDto> lists)
        {
            if (lists == null)
            {
                return BadRequest("ContentBlockDoubleTextDto cannot be null");
            }
            await _contentBlockService.Add(lists);
            return Ok();
        }
        [HttpGet("{questionTypeId}/{status}")]
        public async Task<IActionResult> GetByStatus(Guid questionTypeId, byte status)
        {
            var lists = await _contentBlockService.GetByStatus(questionTypeId, status);
            if (lists == null)
            {
                return BadRequest("ContentBlock is null");
            }
            return Ok(lists);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _contentBlockService.DeleteAsync(id);
            return Ok();
        }
        [HttpPost("status")]
        public async Task<IActionResult> ChangeStatus(ContentBlockStatusDto contentBlockStatusDto)
        {
            await _contentBlockService.ChangeStatus(contentBlockStatusDto);
            return Ok();
        }

        [HttpGet("question-type/{contentBlockId}")]
        public async Task<IActionResult> GetQuestionTypeName(Guid contentBlockId)
        {
            string name = await _contentBlockService.GetQuestionTypeName(contentBlockId);
            
            return Ok(name);
        }

        [HttpPut("approve/{contentBlockId}")]
        public async Task<IActionResult> Approve(Guid contentBlockId)
        {
            await _contentBlockService.Approve(contentBlockId);

            return Ok();
        }

        [HttpPut("reject")]
        public async Task<IActionResult> Reject(ContentBlockRejectDto contentBlockRejectDto)
        {
            await _contentBlockService.Reject(contentBlockRejectDto);

            return Ok();
        }
    }
}
