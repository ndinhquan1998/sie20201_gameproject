// GENERATED AUTOMATICALLY FROM 'Assets/Core Game/Scripts/Game System/Game Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""bca0d566-3289-46af-b22b-47b57269a637"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3f5af345-b990-4941-83a5-4a74ecdc5166"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""49988638-704d-456b-8a53-33e3c375bc43"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lock On Target Left"",
                    ""type"": ""Button"",
                    ""id"": ""b53fc1a1-6520-432d-a5d2-b15f4124f89b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lock On Target  Right"",
                    ""type"": ""Button"",
                    ""id"": ""cc43d10b-7cb1-4b26-bc3c-d683b34d49ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""baf64e1e-1e86-4b49-9022-6564dc0e784a"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8d3571e7-0212-4d78-9096-db75ee9176bc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""aaccfed2-6821-4b99-bf8b-bd612f7f6dac"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bf234faa-b358-42b5-a001-dcccaff79777"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8c0920b0-4d8d-4447-979b-53d2f9be0539"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1d43b588-be09-4b2b-9da6-18cf68a06a4a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52929d0e-2bec-49c2-a286-d61b00680dfb"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f71ac01-2131-41c0-8707-1f038d5700f4"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45cbe0a5-715d-4085-b881-2a4ce72374f9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""256b7124-1253-42da-8bca-dbe2c3c3095b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61506490-b024-400f-9d8f-8c2ec426b8c1"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Lock On Target Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cf7d6a4-5723-4458-9299-5a09b3fff516"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Lock On Target Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6ff4ec6-967f-47e7-92fe-bb566be73a30"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Lock On Target Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d07f7553-f1a4-43f6-9744-5c9ac674afad"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Lock On Target  Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c39e49b4-0f19-4d43-9bff-7d07223b99f1"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Lock On Target  Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93f118eb-a4da-4f6d-868b-6b82893f8d13"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Lock On Target  Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player Actions"",
            ""id"": ""87887478-0e5c-40aa-8b52-c97372eb7125"",
            ""actions"": [
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""1e653050-6ad7-4bee-8a8a-7a1669165bd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RB"",
                    ""type"": ""Button"",
                    ""id"": ""187dd7c2-ed94-4113-b6b1-792323a2ba73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""f2964997-0083-437d-98c0-8571516abb7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LT"",
                    ""type"": ""Button"",
                    ""id"": ""0f468499-e9fe-4a25-9675-06d55467bcc0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LB"",
                    ""type"": ""Button"",
                    ""id"": ""5c64f512-6d5d-427d-8fab-d3354a26ed0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""649fa657-f897-485a-8723-0c3a75c4b902"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""8e61146a-54c1-4b81-be57-23cf3483da83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""2d382882-2a82-4f2d-abe5-44ad61541b67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""b6ae52de-28f9-42fd-ae18-54e49257369f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""074134b0-1b95-4472-a68f-2ea0e0c0a0cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""9d3edcb2-bb3e-4193-a114-0006f0b950e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Critical Attack"",
                    ""type"": ""Button"",
                    ""id"": ""9d5f7f73-af54-4467-866b-e3b7e2136a36"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f37ab0a-6829-4c78-a6e5-2b3634398c66"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""772ffd81-28a7-49fa-894b-c869d4f73340"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffa0f114-fdb3-4e7a-853a-43fa54727a32"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5dc84db-4eb2-47cc-8325-bf0a6ca68a35"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85facb38-8ceb-4fcd-a5f4-b5199424afa8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a1f2089-76c9-4088-8e30-382f057cba16"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c43177c-5709-42f2-89ca-fa4b99ca9f86"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9628adc7-fa91-418f-974a-6bcd4676e11f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8f0a268-251d-45a2-b599-a31a8c02ab06"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e8f389a-226c-4d36-ae55-6ed668e462fb"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e6cf010-d232-4f38-a0ae-08952ddfef10"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a94e3c0-06ca-4ca4-84c9-fb794c7cdb1b"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19f6119a-0434-4f2a-84de-0e558489ba01"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3944ac9c-5f3b-41e6-b54d-aaed39a7a1e3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bf63ea3-a7ed-4aaf-b540-1c2aa873c951"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6f92380-d145-42f0-93a6-d53177245ec0"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50f82b79-b858-4975-aca0-8ca3700051a7"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed177dfa-3694-48cb-996e-7fdd01432de3"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76fc2cab-7fb8-49a3-8fb2-d11dd9491e18"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b115aac-f9b1-4ab4-9e20-18e182fdd3f2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""786de5fe-f7c5-48c2-928a-12705e648ba9"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2e12318-a2a5-464f-9bbd-70fb56dc9627"",
                    ""path"": ""<DualShockGamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9231e7a-18fa-461c-985e-156a527c9d11"",
                    ""path"": ""<XInputController>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d889d7d6-b6eb-4f56-a753-99e9ce52664b"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2c4d08f-9e50-4ffe-acf9-6ef6182f704b"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93799d3c-1315-4aef-96a1-33755d9f11f8"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc8865d8-ab63-483e-be49-0fef7564c123"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9d89cd6-a93b-4eb9-a649-e0940f88ef18"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61e43f82-629c-489f-8e53-e2deaf173ae8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Critical Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70a5096f-c6a2-47ba-8fb7-72179fb11508"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbd915bd-bb62-4469-a7e0-06c407ee5c55"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a6773f4-0aab-4954-a9db-1066454077d3"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e979f210-0fd3-4d17-a4c4-2a0f196db74c"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10825e8e-52c3-45ef-8656-2bf9a2db13cb"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f0dab06-7ede-4c6c-ab91-0d98cbfd9888"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7e699a4-082b-4f17-bac0-a1f85ea05452"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb5f5803-6baa-4924-a919-317fcaae20fc"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdca7fcf-11dd-4f7c-aa8a-02ae45bc2e0b"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Dualshock Controller"",
                    ""action"": ""Critical Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a07a408-782b-4dba-8305-04f423d9de59"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Critical Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player Quick Slots"",
            ""id"": ""ebb02897-1d4a-4e6f-9359-621983702e41"",
            ""actions"": [
                {
                    ""name"": ""D-Pad Right"",
                    ""type"": ""Button"",
                    ""id"": ""e7b5cfbc-94bd-464e-be17-bb879c969433"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Left"",
                    ""type"": ""Button"",
                    ""id"": ""c6cf3877-dd36-471e-a4a9-06b5773f44b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Down"",
                    ""type"": ""Button"",
                    ""id"": ""ddff4af9-1105-4bb5-aa8a-534b58eb7085"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Up"",
                    ""type"": ""Button"",
                    ""id"": ""27f528b2-6171-41f5-85af-77554a4576d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c27893ab-5a62-42c8-8435-fd2b5d0fd95b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80cb9707-339e-4893-ab80-f78c2558cc94"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""D-Pad Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f3c40b7-0eb0-4d59-ae31-7faf57ff7bc1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""D-Pad Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de3fc15e-6cf0-423f-8121-90d23d7e0056"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""615e9970-35f0-4953-85a0-7d0918861642"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d271324-6580-447a-bfa2-2b935582e156"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""D-Pad Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ab1d671-f9cd-4154-9cc9-55ad98135392"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11de6b17-7660-4f5b-a277-ff782c5ead9b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""D-Pad Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Dualshock Controller"",
            ""bindingGroup"": ""Dualshock Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Xbox Controller"",
            ""bindingGroup"": ""Xbox Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Camera = m_PlayerMovement.FindAction("Camera", throwIfNotFound: true);
        m_PlayerMovement_LockOnTargetLeft = m_PlayerMovement.FindAction("Lock On Target Left", throwIfNotFound: true);
        m_PlayerMovement_LockOnTargetRight = m_PlayerMovement.FindAction("Lock On Target  Right", throwIfNotFound: true);
        // Player Actions
        m_PlayerActions = asset.FindActionMap("Player Actions", throwIfNotFound: true);
        m_PlayerActions_B = m_PlayerActions.FindAction("B", throwIfNotFound: true);
        m_PlayerActions_RB = m_PlayerActions.FindAction("RB", throwIfNotFound: true);
        m_PlayerActions_RT = m_PlayerActions.FindAction("RT", throwIfNotFound: true);
        m_PlayerActions_LT = m_PlayerActions.FindAction("LT", throwIfNotFound: true);
        m_PlayerActions_LB = m_PlayerActions.FindAction("LB", throwIfNotFound: true);
        m_PlayerActions_A = m_PlayerActions.FindAction("A", throwIfNotFound: true);
        m_PlayerActions_Y = m_PlayerActions.FindAction("Y", throwIfNotFound: true);
        m_PlayerActions_X = m_PlayerActions.FindAction("X", throwIfNotFound: true);
        m_PlayerActions_LockOn = m_PlayerActions.FindAction("LockOn", throwIfNotFound: true);
        m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActions_Inventory = m_PlayerActions.FindAction("Inventory", throwIfNotFound: true);
        m_PlayerActions_CriticalAttack = m_PlayerActions.FindAction("Critical Attack", throwIfNotFound: true);
        // Player Quick Slots
        m_PlayerQuickSlots = asset.FindActionMap("Player Quick Slots", throwIfNotFound: true);
        m_PlayerQuickSlots_DPadRight = m_PlayerQuickSlots.FindAction("D-Pad Right", throwIfNotFound: true);
        m_PlayerQuickSlots_DPadLeft = m_PlayerQuickSlots.FindAction("D-Pad Left", throwIfNotFound: true);
        m_PlayerQuickSlots_DPadDown = m_PlayerQuickSlots.FindAction("D-Pad Down", throwIfNotFound: true);
        m_PlayerQuickSlots_DPadUp = m_PlayerQuickSlots.FindAction("D-Pad Up", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Camera;
    private readonly InputAction m_PlayerMovement_LockOnTargetLeft;
    private readonly InputAction m_PlayerMovement_LockOnTargetRight;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Camera => m_Wrapper.m_PlayerMovement_Camera;
        public InputAction @LockOnTargetLeft => m_Wrapper.m_PlayerMovement_LockOnTargetLeft;
        public InputAction @LockOnTargetRight => m_Wrapper.m_PlayerMovement_LockOnTargetRight;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @LockOnTargetLeft.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetLeft;
                @LockOnTargetLeft.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetLeft;
                @LockOnTargetLeft.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetLeft;
                @LockOnTargetRight.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetRight;
                @LockOnTargetRight.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetRight;
                @LockOnTargetRight.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetRight;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @LockOnTargetLeft.started += instance.OnLockOnTargetLeft;
                @LockOnTargetLeft.performed += instance.OnLockOnTargetLeft;
                @LockOnTargetLeft.canceled += instance.OnLockOnTargetLeft;
                @LockOnTargetRight.started += instance.OnLockOnTargetRight;
                @LockOnTargetRight.performed += instance.OnLockOnTargetRight;
                @LockOnTargetRight.canceled += instance.OnLockOnTargetRight;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Player Actions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_B;
    private readonly InputAction m_PlayerActions_RB;
    private readonly InputAction m_PlayerActions_RT;
    private readonly InputAction m_PlayerActions_LT;
    private readonly InputAction m_PlayerActions_LB;
    private readonly InputAction m_PlayerActions_A;
    private readonly InputAction m_PlayerActions_Y;
    private readonly InputAction m_PlayerActions_X;
    private readonly InputAction m_PlayerActions_LockOn;
    private readonly InputAction m_PlayerActions_Jump;
    private readonly InputAction m_PlayerActions_Inventory;
    private readonly InputAction m_PlayerActions_CriticalAttack;
    public struct PlayerActionsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @B => m_Wrapper.m_PlayerActions_B;
        public InputAction @RB => m_Wrapper.m_PlayerActions_RB;
        public InputAction @RT => m_Wrapper.m_PlayerActions_RT;
        public InputAction @LT => m_Wrapper.m_PlayerActions_LT;
        public InputAction @LB => m_Wrapper.m_PlayerActions_LB;
        public InputAction @A => m_Wrapper.m_PlayerActions_A;
        public InputAction @Y => m_Wrapper.m_PlayerActions_Y;
        public InputAction @X => m_Wrapper.m_PlayerActions_X;
        public InputAction @LockOn => m_Wrapper.m_PlayerActions_LockOn;
        public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
        public InputAction @Inventory => m_Wrapper.m_PlayerActions_Inventory;
        public InputAction @CriticalAttack => m_Wrapper.m_PlayerActions_CriticalAttack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @B.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnB;
                @RB.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RB.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RB.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RT.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RT.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RT.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @LT.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLT;
                @LT.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLT;
                @LT.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLT;
                @LB.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLB;
                @LB.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLB;
                @LB.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLB;
                @A.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnA;
                @Y.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnY;
                @Y.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnY;
                @Y.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnY;
                @X.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnX;
                @LockOn.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLockOn;
                @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Inventory.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInventory;
                @CriticalAttack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCriticalAttack;
                @CriticalAttack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCriticalAttack;
                @CriticalAttack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCriticalAttack;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @RB.started += instance.OnRB;
                @RB.performed += instance.OnRB;
                @RB.canceled += instance.OnRB;
                @RT.started += instance.OnRT;
                @RT.performed += instance.OnRT;
                @RT.canceled += instance.OnRT;
                @LT.started += instance.OnLT;
                @LT.performed += instance.OnLT;
                @LT.canceled += instance.OnLT;
                @LB.started += instance.OnLB;
                @LB.performed += instance.OnLB;
                @LB.canceled += instance.OnLB;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @Y.started += instance.OnY;
                @Y.performed += instance.OnY;
                @Y.canceled += instance.OnY;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @CriticalAttack.started += instance.OnCriticalAttack;
                @CriticalAttack.performed += instance.OnCriticalAttack;
                @CriticalAttack.canceled += instance.OnCriticalAttack;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // Player Quick Slots
    private readonly InputActionMap m_PlayerQuickSlots;
    private IPlayerQuickSlotsActions m_PlayerQuickSlotsActionsCallbackInterface;
    private readonly InputAction m_PlayerQuickSlots_DPadRight;
    private readonly InputAction m_PlayerQuickSlots_DPadLeft;
    private readonly InputAction m_PlayerQuickSlots_DPadDown;
    private readonly InputAction m_PlayerQuickSlots_DPadUp;
    public struct PlayerQuickSlotsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerQuickSlotsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @DPadRight => m_Wrapper.m_PlayerQuickSlots_DPadRight;
        public InputAction @DPadLeft => m_Wrapper.m_PlayerQuickSlots_DPadLeft;
        public InputAction @DPadDown => m_Wrapper.m_PlayerQuickSlots_DPadDown;
        public InputAction @DPadUp => m_Wrapper.m_PlayerQuickSlots_DPadUp;
        public InputActionMap Get() { return m_Wrapper.m_PlayerQuickSlots; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerQuickSlotsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerQuickSlotsActions instance)
        {
            if (m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface != null)
            {
                @DPadRight.started -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadRight;
                @DPadRight.performed -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadRight;
                @DPadRight.canceled -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadRight;
                @DPadLeft.started -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.performed -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.canceled -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadLeft;
                @DPadDown.started -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadDown;
                @DPadDown.performed -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadDown;
                @DPadDown.canceled -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadDown;
                @DPadUp.started -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadUp;
                @DPadUp.performed -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadUp;
                @DPadUp.canceled -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadUp;
            }
            m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DPadRight.started += instance.OnDPadRight;
                @DPadRight.performed += instance.OnDPadRight;
                @DPadRight.canceled += instance.OnDPadRight;
                @DPadLeft.started += instance.OnDPadLeft;
                @DPadLeft.performed += instance.OnDPadLeft;
                @DPadLeft.canceled += instance.OnDPadLeft;
                @DPadDown.started += instance.OnDPadDown;
                @DPadDown.performed += instance.OnDPadDown;
                @DPadDown.canceled += instance.OnDPadDown;
                @DPadUp.started += instance.OnDPadUp;
                @DPadUp.performed += instance.OnDPadUp;
                @DPadUp.canceled += instance.OnDPadUp;
            }
        }
    }
    public PlayerQuickSlotsActions @PlayerQuickSlots => new PlayerQuickSlotsActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_DualshockControllerSchemeIndex = -1;
    public InputControlScheme DualshockControllerScheme
    {
        get
        {
            if (m_DualshockControllerSchemeIndex == -1) m_DualshockControllerSchemeIndex = asset.FindControlSchemeIndex("Dualshock Controller");
            return asset.controlSchemes[m_DualshockControllerSchemeIndex];
        }
    }
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("Xbox Controller");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnLockOnTargetLeft(InputAction.CallbackContext context);
        void OnLockOnTargetRight(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnB(InputAction.CallbackContext context);
        void OnRB(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnLT(InputAction.CallbackContext context);
        void OnLB(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnCriticalAttack(InputAction.CallbackContext context);
    }
    public interface IPlayerQuickSlotsActions
    {
        void OnDPadRight(InputAction.CallbackContext context);
        void OnDPadLeft(InputAction.CallbackContext context);
        void OnDPadDown(InputAction.CallbackContext context);
        void OnDPadUp(InputAction.CallbackContext context);
    }
}
