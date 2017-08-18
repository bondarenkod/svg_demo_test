using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using svg_demo_test.Helpers;
using svg_demo_test.Models;
using svg_demo_test.Views;

using Xamarin.Forms;

namespace svg_demo_test.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		public ItemsViewModel()
		{
			Title = "Browse";
			Items = new ObservableRangeCollection<Item>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
			{
				//var _item = item as Item;
				//Items.Add(_item);
				//await DataStore.AddItemAsync(_item);
			});
		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;



			IsBusy = true;

			try
			{
				Items.Clear();
				//var items = await DataStore.GetItemsAsync(true);

				var icons = GetIcons();

				var items = icons.Select(x =>
				{
					return new Item()
					{
						//resource://FFImageLoading.Forms.Sample.Resources.sample.svg
						//resource://FFImageLoading.Forms.Sample.Resources.sample.svg?assembly=[ASSEMBLY FULL NAME]
						//IconsPackDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
						//IconPath = $"resource://IconsPackDemo.Resources.{x}",

						//IconPath = $"resource://svg_demo_test.Resources.{x}",

						IconPath = $"resource://IconsPackDemo.Resources.{x}?assembly=IconsPackDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
						//IconPath = "resource://IconsPackDemo.Resources.svgdemo.svg?assembly=IconsPackDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
						Description = x,
						Size = 50
					};
				});

				Items.ReplaceRange(items);
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex);
				MessagingCenter.Send(new MessagingCenterAlert
				{
					Title = "Error",
					Message = "Unable to load items.",
					Cancel = "OK"
				}, "message");
			}
			finally
			{
				IsBusy = false;
			}
		}

		private string[] GetIcons()
		{
			return new string[]
			{
				"svgdemo.svg",
				"001-laborers-1.svg",
				"002-laborers.svg",
				"003-gloves.svg",
				"004-boots.svg",
				"005-roll-paint-brush.svg",
				"006-tool-box.svg",
				"007-cone.svg",
				"008-color-palette.svg",
				"009-shovel.svg",
				"010-barrier.svg",
				"011-tank-truck.svg",
				"012-steamroller.svg",
				"013-forklift.svg",
				"014-truck-1.svg",
				"015-truck.svg",
				"016-excavator-2.svg",
				"017-excavator-1.svg",
				"018-demolition.svg",
				"019-crane-2.svg",
				"020-excavator.svg",
				"021-window.svg",
				"022-door.svg",
				"023-construction-vest.svg",
				"024-construction-2.svg",
				"025-hydraulic-breaker.svg",
				"026-glasses.svg",
				"027-hacksaw.svg",
				"028-nail.svg",
				"029-trowel.svg",
				"030-crane-1.svg",
				"031-saw.svg",
				"032-plumber.svg",
				"033-brick.svg",
				"034-sign.svg",
				"035-wheelbarrow.svg",
				"036-pliers.svg",
				"037-construction-1.svg",
				"038-demolition-crane.svg",
				"039-crane.svg",
				"040-paint-brush.svg",
				"041-hammer.svg",
				"042-screwdriver.svg",
				"043-measuring-tape.svg",
				"044-house.svg",
				"045-building.svg",
				"046-construction.svg",
				"047-house-sketch.svg",
				"048-paint-bucket.svg",
				"049-drill.svg",
				"050-blowtorch.svg",
			};
		}
	}
}