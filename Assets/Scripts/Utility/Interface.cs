
// 데미지 받기
public interface IDamageable
{
    void TakeDamage(int damage);
}

// 전체 무기 - 플레이어 무기
public interface IWeapon
{
    void TakeAttack(int damage);
}