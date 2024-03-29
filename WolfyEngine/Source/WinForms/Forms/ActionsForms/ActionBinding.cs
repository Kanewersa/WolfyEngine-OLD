﻿using System;
using System.Collections.Generic;
using WolfyCore.Actions;
using WolfyCore.ECS;

namespace WolfyEngine.Forms
{
    public static class ActionBinding
    {
        private static readonly Dictionary<Type, Type> ActionTypes = new Dictionary<Type, Type>
        {
            { typeof(TeleportAction), typeof(TeleportActionForm) },
            { typeof(DialogAction), typeof(StartDialogForm) },
            { typeof(CameraFadeAction), typeof(CameraFadeActionForm) },
            { typeof(ChangeBGMAction), typeof(ChangeBGMActionForm)},
            { typeof(BoolCondition), typeof(CreateConditionForm)},
            { typeof(VariableCondition), typeof(CreateConditionForm)}
            //{ typeof(MovementAction), typeof(MovementForm) }
        };

        private static Type GetFormType(Type actionType)
        {
            if(!ActionTypes.ContainsKey(actionType))
                throw new NullReferenceException("Type "
                                                 + actionType.FullName
                                                 + " was not declared in ActionBinding.");
            return ActionTypes[actionType];
        }

        public static dynamic GetFormInstance(WolfyAction action)
        {
            var formType = GetFormType(action.GetType());
            return Convert.ChangeType(Activator.CreateInstance(formType), formType);
        }
    }
}
