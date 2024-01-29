namespace portfolio.Server.Controllers
{
    public interface ICrudController<T>
    {
        Task<List<T>> Get();
        Task<ActionResult<T>> Get(Guid id);
        Task<ActionResult<T>> Post(T newEntity);
        Task<ActionResult> Put(Guid id, T updateEntity);
        Task<ActionResult> Delete(Guid id);
    }

    [Route("api/[controller]")]
    [ApiController]
    public abstract class CrudControllerBase<T> : ControllerBase, ICrudController<T>
    {
        private readonly IRepository<T> _service;

        protected CrudControllerBase(IRepository<T> service) => _service = service;

        [HttpGet]
        public async Task<List<T>> Get() => await _service.GetAsync();

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<T>> Get(Guid id)
        {
            T entity = await _service.GetAsync(id);
            if (entity == null)
                return NotFound();

            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post([FromBody] T newEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CreateAsync(newEntity);
            return CreatedAtAction(nameof(Get), new { id = GetEntityId(newEntity) }, newEntity);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] T updateEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            T entity = await _service.GetAsync(id);
            if (entity == null)
                return NotFound($"There is no {typeof(T).Name} with this id: {id}");

            SetEntityId(updateEntity, id);

            await _service.UpdateAsync(id, updateEntity);

            return Ok("Updated Successfully");
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            T entity = await _service.GetAsync(id);
            if (entity == null)
                return NotFound($"There is no {typeof(T).Name} with this id: {id}");

            await _service.RemoveAsync(id);

            return Ok("Deleted Successfully");
        }

        protected abstract Guid GetEntityId(T entity);
        protected abstract void SetEntityId(T entity, Guid id);
    }

    #region Controllers
    #region History
    public class EducationController : CrudControllerBase<Education>
        {
            public EducationController(IRepository<Education> educationService) : base(educationService) { }
            protected override Guid GetEntityId(Education entity) => entity.Id;
            protected override void SetEntityId(Education entity, Guid id) => entity.Id = id;
        }
    public class VoluntarilyController : CrudControllerBase<Voluntarily>
        {
            public VoluntarilyController(IRepository<Voluntarily> voluntarilyService) : base(voluntarilyService) { }
            protected override Guid GetEntityId(Voluntarily entity) => entity.Id;
            protected override void SetEntityId(Voluntarily entity, Guid id) => entity.Id = id;
        }
    public class WorkExperienceController : CrudControllerBase<WorkExperience>
        {
            public WorkExperienceController(IRepository<WorkExperience> workExperienceService) : base(workExperienceService) { }
            protected override Guid GetEntityId(WorkExperience entity) => entity.Id;
            protected override void SetEntityId(WorkExperience entity, Guid id) => entity.Id = id;
        }
    #endregion

    #region About
    public class AboutController : CrudControllerBase<About>
    {
        public AboutController(IRepository<About> aboutService) : base(aboutService) { }
        protected override Guid GetEntityId(About entity) => entity.Id;
        protected override void SetEntityId(About entity, Guid id) => entity.Id = id;
    }
    public class HobbiesController : CrudControllerBase<Hobbies>
    {
        public HobbiesController(IRepository<Hobbies> hobbiesService) : base(hobbiesService) { }
        protected override Guid GetEntityId(Hobbies entity) => entity.Id;
        protected override void SetEntityId(Hobbies entity, Guid id) => entity.Id = id;
    }
    public class MiniBioController : CrudControllerBase<MiniBio>
    {
        public MiniBioController(IRepository<MiniBio> miniBioService) : base(miniBioService) { }
        protected override Guid GetEntityId(MiniBio entity) => entity.Id;
        protected override void SetEntityId(MiniBio entity, Guid id) => entity.Id = id;
    }
    public class SkillsController : CrudControllerBase<Skills>
    {
        public SkillsController(IRepository<Skills> skillsService) : base(skillsService) { }
        protected override Guid GetEntityId(Skills entity) => entity.Id;
        protected override void SetEntityId(Skills entity, Guid id) => entity.Id = id;
    }
    public class SocialsController : CrudControllerBase<Socials>
    {
        public SocialsController(IRepository<Socials> socialsService) : base(socialsService) { }
        protected override Guid GetEntityId(Socials entity) => entity.Id;
        protected override void SetEntityId(Socials entity, Guid id) => entity.Id = id;
    }
    #endregion

    public class ContentFileController : CrudControllerBase<ContentFile>
        {
            public ContentFileController(IRepository<ContentFile> contentFileRepository) : base(contentFileRepository) { }
            protected override Guid GetEntityId(ContentFile entity) => entity.Id;
            protected override void SetEntityId(ContentFile entity, Guid id) => entity.Id = id;
        }
    public class RecommendationController : CrudControllerBase<Recommendation>
        {
            public RecommendationController(IRepository<Recommendation> recommendationService) : base(recommendationService) { }
            protected override Guid GetEntityId(Recommendation entity) => entity.Id;
            protected override void SetEntityId(Recommendation entity, Guid id) => entity.Id = id;
        }
    #endregion
}
