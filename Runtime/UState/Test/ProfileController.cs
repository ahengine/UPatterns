using UnityEngine;

namespace UPatterns.Test
{
     public class ProfileController : Singleton<ProfileController>
     {
          [TextArea,SerializeField] private string profileJson;

          public void SetData()
          {
               ProfileState state = UState.FromJson<ProfileState>(profileJson);
               UStateRepo.SetState(state);
               print("Profile Set Data");
          }

          public void GetData()
          {
               var state = UStateRepo.GetState<ProfileState>();
               print(state.ToString());
               print("Profile Get Data");
          }
     }
}