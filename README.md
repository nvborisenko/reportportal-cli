# reportportal-cli
Command line utility to interact with http://reportportal.io API

This is command line utility, would be nice to have it to interact with ReportPortal API.

# Install

## As dotnet tool from nuget.org
```
dotnet tool install reportportal.cli -g
```

# Usage
Then we need configure a connection with api
```cmd
reportportal connect -s http://<host>/api/v1 -p <some_project> -t <some_api_token>
```

And start a launch
```cmd
reportportal launch start -n <some_name> -d <some_description>
```

And finish the launch
```cmd
reportportal launch finish -s passed
```

Or search for launches
```cmd
reportportal launch get --filter name.cnt=<some_part_of_name>
```

# Global context
It's important that tool sets/shares global context. When tool creates a launch, its sets ID of launch as global variable. Then all commands, which want to interact with launch, do it implicitly.

```cmd
reportportal test get
```

This command should show all tests that belong to previously set launch.

# Configuration
Open question where to store configuration. In current user's local location, or in working directory, or in environment variables.
