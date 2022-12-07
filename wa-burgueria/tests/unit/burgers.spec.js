import mockAxios from "jest-mock-axios";
import BurgersService from "@/services/burgers";

describe("IngredientsService 🍔🍔🍔", () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  it("should return a list of burgers from backend", async () => {
    const burgers = [
      {
        nome: "Mariane Squenquel Peixe",
        carne: "Alcatra",
        pao: "Integral",
        opcionais: ["Bacon", "Salame"],
        status: "Solicitado",
        id: 1,
      },
      {
        nome: "Sharpzin",
        carne: "Picanha",
        pao: "3 Queijos",
        opcionais: ["Cheddar", "Tomate", "Pepino"],
        status: "Finalizado",
        id: 2,
      },
    ];
    mockAxios.get.mockImplementationOnce(() => {
      return Promise.resolve({ data: { burgers } });
    });

    const response = await BurgersService(mockAxios).getBurgers();

    expect(response.data).toHaveProperty("burgers");
    expect(response.data).toMatchSnapshot();
  });

  it("should create a Order with a burger product", async () => {
    const burger = {
      nome: "Jose Cabaninha",
      carne: "Picanha",
      pao: "Integral",
      opcionais: ["Cheddar", "Tomate"],
      status: "Solicitado",
      id: 3,
    };

    mockAxios.post.mockImplementationOnce(() => {
      return Promise.resolve({ data: burger });
    });

    const response = await BurgersService(mockAxios).createOrder({ burger });

    expect(response.data).toHaveProperty(
      "nome",
      "pao",
      "carne",
      "opcionais",
      "status"
    );
    expect(response.data).toMatchSnapshot();
  });
});
