﻿using Cofoundry.Domain.Extendable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Domain
{
    public class ContentRepositoryPageVersionsByPageIdQueryBuilder
        : IAdvancedContentRepositoryPageVersionsByPageIdQueryBuilder
        , IExtendableContentRepositoryPart
    {
        public ContentRepositoryPageVersionsByPageIdQueryBuilder(
            IExtendableContentRepository contentRepository
            )
        {
            ExtendableContentRepository = contentRepository;
        }

        public IExtendableContentRepository ExtendableContentRepository { get; }

        public IContentRepositoryQueryContext<PagedQueryResult<PageVersionSummary>> AsVersionSummaries(GetPageVersionSummariesByPageIdQuery query)
        {
            return ContentRepositoryQueryContextFactory.Create(query, ExtendableContentRepository);
        }
    }
}
