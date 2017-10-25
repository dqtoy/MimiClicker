﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Transform m_enemySpawnPos;
	[SerializeField] private Transform m_enemyGoalPos;

	private float m_enemySpawnTimer = 0;
	private bool m_isInitialized = false;

	private void Update()
	{
		if (!m_isInitialized) return;

		var enemy = GameController.I.GetEnemy();
		if (enemy == null)
		{
			m_enemySpawnTimer -= Time.deltaTime;

			if (m_enemySpawnTimer <= 0)
			{
				m_enemySpawnTimer = 5;
				Spawn();
			}
		}
	}

	public void Setup(Action onSetupComplete)
	{
		m_isInitialized = true;

		onSetupComplete();
	}

	private void Spawn()
	{
		var prefab = Resources.Load("Prefabs/Character/Enemy") as GameObject;
		var go = Instantiate(prefab, transform);
		var enemy = go.GetComponent<Enemy>();

		enemy.Setup(() => {
			// 移動完了時
			enemy.StartOpening();
		});
		enemy.Move(m_enemySpawnPos.position, m_enemyGoalPos.position);

		GameController.I.SetEnemy(enemy);
	}
}