using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Sight
{
    public struct Tile
    {
        public Vector3 tilePos;
        public bool isCheck;
    }

    public class CharacterSight : MonoBehaviour
    {
        #region Private Field
        [SerializeField] private float tileSize;
        [SerializeField] private int fogWidthX, fogWidthZ;
        [SerializeField] private GameObject plane;
        [SerializeField] private GameObject pivot;
        [SerializeField] private LayerMask groundLayer;

        [SerializeReference] private Tile[,] tilemap;
        #endregion

        #region Public Field
        #endregion

        #region Property
        #endregion

        /***********************************************************************
        *                               event
        ***********************************************************************/
        #region
        private void Start()
        {
            initializeTilemap();
        }

        private void Update()
        {
            ResetTileMap();
        }
        #endregion

        /***********************************************************************
        *                           private method
        ***********************************************************************/
        #region
        private void initializeTilemap()
        {
            tilemap = new Tile[(int)(fogWidthX / tileSize), (int)(fogWidthZ / tileSize)];

            for (int i =0; i< tilemap.GetLength(0); i++)
            {
                for(int j =0; j< tilemap.GetLength(1); j++)
                {
                    var center = getTileCenterPoint(i, j);
                    var height          = getTileHeight(center);

                    tilemap[i, j].tilePos = new Vector3(center.x, height, center.y);
                    tilemap[i, j].isCheck = false;
                }
            }
        }

        private Vector2 getTileCenterPoint(int x_, int y_)
        {
            return new Vector2(
                x_ * tileSize + tileSize * 0.5f - fogWidthZ * 0.5f,
                y_ * tileSize + tileSize * 0.5f - fogWidthX * 0.5f
            );
        }

        private float getTileHeight(Vector2 tileCenterPoint_)
        {
            Vector3 ro = new Vector3(tileCenterPoint_.x, 100f, tileCenterPoint_.y);
            Vector3 rd = Vector3.down;
            float height = 0f;

            if (Physics.Raycast(ro, rd, out var hit, 200f, groundLayer))
            {
                height = hit.point.y;
            }

            return height;
        }

        /// <summary> 대상 유닛의 위치를 타일좌표(x, y, height)로 환산 </summary>
        private Vector3 getTilePosOfUnit(GameObject gameObject)
        {
            int x = (int)((gameObject.transform.position.x - transform.position.x + fogWidthX * 0.5f) / tileSize);
            int y = (int)((gameObject.transform.position.z - transform.position.z + fogWidthZ * 0.5f) / tileSize);
            float height = gameObject.transform.position.y;

            return new Vector3(x, height, y);
        }
        #endregion

        /***********************************************************************
        *                           public method
        ***********************************************************************/
        #region
        /// <summary> 매 계산마다 실행, 모든 타일맵 시야 check 'false'로 초기화 </summary>
        public void ResetTileMap()
        {
            for (int i = 0; i < tilemap.GetLength(0); i++)
            {
                for (int j = 0; j < tilemap.GetLength(1); j++)
                {
                    tilemap[i, j].isCheck = false;
                }
            }
        }
        #endregion

        /***********************************************************************
        *                              editor
        ***********************************************************************/
        #region
        private void OnDrawGizmos()
        {
            if (Application.isPlaying == false) return;

        #if DEBUG_RANGE
        #endif

            if (tilemap != null)
            {
                // 전체 타일 그리드, 장애물 그리드 보여주기
                for (int i = 0; i < tilemap.GetLength(0); i++)
                {
                    for (int j = 0; j < tilemap.GetLength(1); j++)
                    {
                        Vector2 center = getTileCenterPoint(i, j);

                        Gizmos.color = new Color(tilemap[i, j].tilePos.y - transform.position.y, 0, 0);
                        Gizmos.DrawWireCube(new Vector3(center.x, transform.position.y, center.y)
                            , new Vector3(tileSize - 0.02f, 0f, tileSize - 0.02f));
                    }
                }
            }
        }
        #endregion

    }
}