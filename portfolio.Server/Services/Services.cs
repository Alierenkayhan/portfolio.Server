#region History
using portfolio.Server.Models.About;

public class EducationService : GenericRepository<Education> { public EducationService(IOptions<DatabaseSettings> settings) : base(settings) { } }
public class VoluntarilyService : GenericRepository<Voluntarily> { public VoluntarilyService(IOptions<DatabaseSettings> settings) : base(settings) { } }

public class WorkExperienceService : GenericRepository<WorkExperience> { public WorkExperienceService(IOptions<DatabaseSettings> settings) : base(settings) { } }
#endregion

#region About
public class AboutService : GenericRepository<About> { public AboutService(IOptions<DatabaseSettings> settings) : base(settings) { } }

public class HobbiesService : GenericRepository<Hobbies> { public HobbiesService(IOptions<DatabaseSettings> settings) : base(settings) { } }

public class MiniBioService : GenericRepository<MiniBio> { public MiniBioService(IOptions<DatabaseSettings> settings) : base(settings) { } }

public class SkillsService : GenericRepository<Skills> { public SkillsService(IOptions<DatabaseSettings> settings) : base(settings) { } }

public class SocialsService : GenericRepository<Socials> { public SocialsService(IOptions<DatabaseSettings> settings) : base(settings) { } }
#endregion

public class ContentFileService : GenericRepository<ContentFile> { public ContentFileService(IOptions<DatabaseSettings> settings) : base(settings) { } }

public class RecommendationService : GenericRepository<Recommendation> { public RecommendationService(IOptions<DatabaseSettings> settings) : base(settings) { } }

public class UserService : GenericRepository<User> { public UserService(IOptions<DatabaseSettings> settings) : base(settings) { } }