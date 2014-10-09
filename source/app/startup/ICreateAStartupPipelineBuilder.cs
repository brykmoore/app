using System;

namespace app.startup
{
  public delegate ICreateStartupPipelines ICreateAStartupPipelineBuilder(Type initial_step);
}