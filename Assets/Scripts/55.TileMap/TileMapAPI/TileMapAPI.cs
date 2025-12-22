using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapAPI : MonoBehaviour
{
    //Tilemap组件:用于管理瓦片地图
    //TileBase组件:瓦片资源对象基类,可以得到瓦片信息
    //Grid组件: 用于坐标转换
    public Tilemap tilemap;
    public TileBase tileBase;
    public Grid grid;
    void Start()
    {
        // 1. 清空瓦片地图
        // this.tilemap.ClearAllTiles();
        // 2. 获取指定坐标的瓦片
        TileBase tile = this.tilemap.GetTile(new Vector3Int(0, 0, 0));
        print(tile);
        // 3. 设置指定坐标的瓦片
        this.tilemap.SetTile(new Vector3Int(1, 1, 0), this.tileBase);

        // this.tilemap.SetTile(Vector3Int.zero, null); // 删除指定坐标的瓦片

        // 设置多张瓦片
        this.tilemap.SetTiles(new Vector3Int[] { new Vector3Int(2, 2, 0), new Vector3Int(3, 3, 0) },
                           new TileBase[] { this.tileBase, this.tileBase });

        // 4. 替换同类瓦片
        this.tilemap.SwapTile(tile, this.tileBase); // 将tile替换为this.tileBase

        //5. 坐标转换(传入的是世界坐标)
        Vector3Int cellPosition = this.grid.WorldToCell(new Vector3(0, 0, 0));
        print(cellPosition);
    }
}
