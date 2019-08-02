using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
	public class SortViewModel
	{
		public SortState UserIdSort { get; private set; }
		public SortState DescSort { get; private set; }
		public SortState OdateSort { get; private set; }
		public SortState CountSort { get; private set; }
		public SortState NameSort { get; private set; }
		public SortState BdateSort { get; private set; }
		public SortState ScoreSort { get; private set; }
		public SortState Current { get; private set; }

		public SortViewModel(SortState sortOrder)
		{
			UserIdSort = sortOrder == SortState.UserIdAsc ? SortState.UserIdDesc : SortState.UserIdAsc;
			DescSort = sortOrder == SortState.DescriptionAsc ? SortState.DescriptionDesc : SortState.DescriptionAsc;
			OdateSort = sortOrder == SortState.OdateAsc ? SortState.OdateDesc : SortState.OdateAsc;
			CountSort = sortOrder == SortState.CntAsc ? SortState.CntDesc : SortState.CntAsc;
			NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
			BdateSort = sortOrder == SortState.BdateAsc ? SortState.BdateDesc : SortState.BdateAsc;
			ScoreSort = sortOrder == SortState.ScoreAsc ? SortState.ScoreDesc : SortState.ScoreAsc;
			Current = sortOrder;
		}
	}
}
