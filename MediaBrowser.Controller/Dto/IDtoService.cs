﻿using MediaBrowser.Controller.Entities;
using MediaBrowser.Model.Dto;
using MediaBrowser.Model.Querying;
using System.Collections.Generic;

namespace MediaBrowser.Controller.Dto
{
    /// <summary>
    /// Interface IDtoService
    /// </summary>
    public interface IDtoService
    {
        /// <summary>
        /// Gets the dto id.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.String.</returns>
        string GetDtoId(BaseItem item);

        /// <summary>
        /// Attaches the primary image aspect ratio.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <param name="item">The item.</param>
        /// <param name="fields">The fields.</param>
        void AttachPrimaryImageAspectRatio(IItemDto dto, IHasImages item, List<ItemFields> fields);

        /// <summary>
        /// Gets the base item dto.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="user">The user.</param>
        /// <param name="owner">The owner.</param>
        /// <returns>Task{BaseItemDto}.</returns>
        BaseItemDto GetBaseItemDto(BaseItem item, List<ItemFields> fields, User user = null, BaseItem owner = null);

        /// <summary>
        /// Gets the base item dto.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="options">The options.</param>
        /// <param name="user">The user.</param>
        /// <param name="owner">The owner.</param>
        /// <returns>BaseItemDto.</returns>
        BaseItemDto GetBaseItemDto(BaseItem item, DtoOptions options, User user = null, BaseItem owner = null);
        
        /// <summary>
        /// Gets the chapter information dto.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>ChapterInfoDto.</returns>
        List<ChapterInfoDto> GetChapterInfoDtos(BaseItem item);

        /// <summary>
        /// Gets the user item data dto.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>UserItemDataDto.</returns>
        UserItemDataDto GetUserItemDataDto(UserItemData data);

        /// <summary>
        /// Gets the item by name dto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="options">The options.</param>
        /// <param name="taggedItems">The tagged items.</param>
        /// <param name="user">The user.</param>
        /// <returns>BaseItemDto.</returns>
        BaseItemDto GetItemByNameDto<T>(T item, DtoOptions options, List<BaseItem> taggedItems, User user = null)
            where T : BaseItem, IItemByName;
    }
}
