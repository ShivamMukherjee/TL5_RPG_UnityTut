using UnityEngine;

public interface IProjectileLauncher
{
	Transform ProjectileSpawnPoint { get; }
	// Supports ?. operator, so it's nullable friendly
	void SetProjectileSpawnPoint(Transform point);
	void LaunchProjectile();
}
