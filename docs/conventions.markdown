﻿#Project Conventions

1. Snake cased method and parameter naming ex. this_is_the_long_method_name_with_spaces_replaced_as_underscores

2. All tests for a component will live in a file named [ComponentName]specs.cs, they will contain an outer class with the name [ComponentName]specs, and all of the tests for the component will be in inner classes of that containing class.

3. Convention over configuration as much as possible to decrease our code surface
  * Should be able to verify our conventions, in an automated way as much as possible

4. Convention for configuration
  * All new micro configuration files should live under the source/config folder and be named:
    [NewConfigName].[real_extension].erb - ex. our_custom_config.txt.erb
