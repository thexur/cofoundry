﻿using Cofoundry.Domain.Extendable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Domain
{
    public class ContentRepositoryPageBlockTypeByIdQueryBuilder
        : IContentRepositoryPageBlockTypeByIdQueryBuilder
        , IExtendableContentRepositoryPart
    {
        private readonly int _pageBlockTypeId;

        public ContentRepositoryPageBlockTypeByIdQueryBuilder(
            IExtendableContentRepository contentRepository,
            int pageBlockTypeId
            )
        {
            ExtendableContentRepository = contentRepository;
            _pageBlockTypeId = pageBlockTypeId;
        }

        public IExtendableContentRepository ExtendableContentRepository { get; }

        public IContentRepositoryQueryContext<PageBlockTypeSummary> AsSummary()
        {
            var query = new GetPageBlockTypeSummaryByIdQuery(_pageBlockTypeId);
            return ContentRepositoryQueryContextFactory.Create(query, ExtendableContentRepository);
        }

        public IContentRepositoryQueryContext<PageBlockTypeDetails> AsDetails()
        {
            var query = new GetPageBlockTypeDetailsByIdQuery(_pageBlockTypeId);
            return ContentRepositoryQueryContextFactory.Create(query, ExtendableContentRepository);
        }
    }
}
