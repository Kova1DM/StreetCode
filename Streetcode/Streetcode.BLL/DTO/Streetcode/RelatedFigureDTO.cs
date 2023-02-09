﻿using Streetcode.BLL.DTO.AdditionalContent;

namespace Streetcode.BLL.DTO.Streetcode;

public class RelatedFigureDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ImageId { get; set; }
    public IEnumerable<TagDTO> Tags { get; set; }
}
