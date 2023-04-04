using Streetcode.DAL.Enums;

namespace Streetcode.BLL.DTO.Timeline;

public class TimelineItemDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string DateString { get; set; }
    public IEnumerable<HistoricalContextDTO> HistoricalContexts { get; set; }
}