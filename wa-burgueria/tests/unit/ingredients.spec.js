import mockAxios from "jest-mock-axios";
import IngredientsService from "@/services/ingredients";

describe("IngredientsService 🍖 🍔 🧀", () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  it("should return a list of ingredients from backend", async () => {
    const ingredientes = {
      "paes": [
        {
          "id": 1,
          "tipo": "Italiano Branco"
        },
        {
          "id": 2,
          "tipo": "3 Queijos"
        },
        {
          "id": 3,
          "tipo": "Parmesão e Orégano"
        },
        {
          "id": 4,
          "tipo": "Integral"
        }
      ],
      "carnes": [
        {
          "id": 1,
          "tipo": "Maminha"
        },
        {
          "id": 2,
          "tipo": "Alcatra"
        },
        {
          "id": 3,
          "tipo": "Picanha"
        },
        {
          "id": 4,
          "tipo": "Veggie burger"
        }
      ],
      "opcionais": [
        {
          "id": 1,
          "tipo": "Bacon"
        },
        {
          "id": 2,
          "tipo": "Cheddar"
        },
        {
          "id": 3,
          "tipo": "Salame"
        },
        {
          "id": 4,
          "tipo": "Tomate"
        },
        {
          "id": 5,
          "tipo": "Cebola roxa"
        },
        {
          "id": 6,
          "tipo": "Pepino"
        }
      ]
    }
    mockAxios.get.mockImplementationOnce(() => {
      return Promise.resolve({ data: { ingredientes }})
    });

    const response = await IngredientsService(mockAxios).getIngredients();

    expect(response.data).toHaveProperty('ingredientes');
    expect(response.data).toMatchSnapshot();
  });

  it("should return an error when not found", async () => {
    const errors = { status: 404, statusText: 'Not Found'}
    mockAxios.get.mockImplementationOnce(() => {
      return Promise.resolve({ request: errors})
    })

    const response = await IngredientsService(mockAxios).getIngredients();

    expect(response.errors).toHaveProperty("status");
    expect(response.errors).toHaveProperty("statusText");
  })
});
