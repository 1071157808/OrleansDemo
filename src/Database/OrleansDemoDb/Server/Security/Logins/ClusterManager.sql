﻿CREATE LOGIN [ClusterManager] 
	WITH PASSWORD = N'MyPa55w0rd!', DEFAULT_DATABASE=[$(DatabaseName)], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON;
