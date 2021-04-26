﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Features.Playlist.Queries;
using Application.Features.Playlist.Commands;
//using Application.Features.Playlist.Commands;

namespace BackendAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PlaylistController : BaseApiController
    {
        #region Queries
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllQuery rq)
        {
            return Ok(await Mediator.Send(rq));
        }

        [HttpGet("ById")]
        public async Task<IActionResult> Get([FromQuery] GetByIdQuery rq)
        {

            return Ok(await Mediator.Send(rq));
        }

        [HttpGet("ByListId")]
        public async Task<IActionResult> GetByListId([FromQuery] GetByListIdQuery rq)
        {

            return Ok(await Mediator.Send(rq));
        }

        [HttpGet("ByName")]
        public async Task<IActionResult> GetByName([FromQuery] GetByNameQuery rq)
        {
            return Ok(await Mediator.Send(rq));
        }

        [HttpGet("MyPlaylist")]
        public async Task<IActionResult> GetMySong([FromQuery] GetPrivateQuery rq)
        {
            return Ok(await Mediator.Send(rq));
        }

        [HttpGet("Comment")]
        public async Task<IActionResult> GetComment([FromQuery] GetCommentQuery rq)
        {
            return Ok(await Mediator.Send(rq));
        }

        [HttpGet("ListSong")]
        public async Task<IActionResult> GetSong([FromQuery] GetSongQuery rq)
        {
            return Ok(await Mediator.Send(rq));
        }

        #endregion

        #region Command
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCommand rq)
        {
            return Ok(await Mediator.Send(rq));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int Id, [FromForm] UpdateCommand rq)
        {
            rq.SetId(Id);
            return Ok(await Mediator.Send(rq));
        }

        //[HttpPut("{SongId}/UpdateType/{TypeId}")]
        //public async Task<IActionResult> UpdateType(int SongId, int TypeId)
        //{
        //    var rq = new UpdateTypeCommand() { Id = SongId, IdTypeUpdate = TypeId };
        //    return Ok(await Mediator.Send(rq));
        //}

        //[HttpPut("{SongId}/UpdateTag/{TagId}")]
        //public async Task<IActionResult> UpdateTag(int SongId, int TagId)
        //{
        //    var rq = new UpdateTagCommand() { Id = SongId, IdTagUpdate = TagId };
        //    return Ok(await Mediator.Send(rq));
        //}

        //[HttpPut("{SongId}/UpdateComposer/{ComposerId}")]
        //public async Task<IActionResult> UpdateComposer(int SongId, int ComposerId)
        //{
        //    var rq = new UpdateComposerCommand() { Id = SongId, IdComposerUpdate = ComposerId };
        //    return Ok(await Mediator.Send(rq));
        //}

        //[HttpPut("{SongId}/UpdateSinger/{SingerId}")]
        //public async Task<IActionResult> UpdateSinger(int SongId, int SingerId)
        //{
        //    var rq = new UpdateSingerCommand() { Id = SongId, IdSingerUpdate = SingerId };
        //    return Ok(await Mediator.Send(rq));
        //}

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int Id)
        {
            var rq = new DeleteCommand();
            rq.SetId(Id);
            return Ok(await Mediator.Send(rq));
        }

        [HttpPost("Reaction")]
        public async Task<IActionResult> Reaction([FromQuery] ReactionCommand rq)
        {
            return Ok(await Mediator.Send(rq));
        }

        [HttpPost("Comment")]
        public async Task<IActionResult> Comment([FromBody] CommentCommand rq)
        {
            return Ok(await Mediator.Send(rq));
        }

        [HttpPost("PushSong")]
        public async Task<IActionResult> PushSongToPlayList([FromQuery] PushSongCommand rq)
        {
            return Ok(await Mediator.Send(rq));
        }

        [HttpDelete("RemoveSong")]
        public async Task<IActionResult> RemoveSongFromPlayist([FromQuery] RemoveSongCommand rq)
        {
            return Ok(await Mediator.Send(rq));
        }
        #endregion
    }
}