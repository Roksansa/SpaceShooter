namespace Interface{
  public interface IBlaster{
    Model.Pooling.Blaster Type { get; set; }
    void Fire();
  }
}