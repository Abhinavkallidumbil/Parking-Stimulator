using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class WaypointManagerWindow : EditorWindow
{
    [MenuItem("Waypoint/Waypoints Editor Tools")]
    public static void ShowWindow()
    {
        GetWindow<WaypointManagerWindow>("Waypoints Editor Tools");
    }
    public Transform waypointOrigin;

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("waypointOrigin"));

        if(waypointOrigin == null)
        {
            EditorGUILayout.HelpBox("please assign a waypoint origin transform .",MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("Box");
            CreateButtons();
            EditorGUILayout.EndVertical();
        }

        obj.ApplyModifiedProperties();
    }
    void CreateButtons()
    {
        if(GUILayout.Button("Create Waypoints"))
        {
            createWaypoints();
        }
    }
    void createWaypoints()
    {
        GameObject waypointObject = new GameObject("Waypoint " + waypointOrigin.childCount, typeof(WayPoint));
        waypointObject.transform.SetParent(waypointOrigin,false);

        WayPoint waypoint = waypointObject.GetComponent<WayPoint>();
        if(waypointOrigin.childCount > 1)
        {
            waypoint.prevoiusWaypoint = waypointOrigin.GetChild(waypointOrigin.childCount-2).GetComponent<WayPoint>();
            waypoint.prevoiusWaypoint.nextWaypoint = waypoint;

            waypoint.transform.position = waypoint.prevoiusWaypoint.transform.position;
            waypoint.transform.forward = waypoint.prevoiusWaypoint.transform.forward;

        }

        Selection.activeGameObject = waypoint.gameObject;
    }
}
