using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data;

namespace Todo.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ITokenRepository _tokenRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public ITokenRepository Token
        {
            get
            {
                if (_tokenRepository == null)
                    _tokenRepository = new TokenRepository(_repositoryContext);
                return _tokenRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();


    }
}
